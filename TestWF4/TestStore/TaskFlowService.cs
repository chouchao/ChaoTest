using System;
using System.Activities;
using System.Activities.DurableInstancing;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.DurableInstancing;
using System.Text;
using System.Threading;
using TestStoreHost.MS.Models;
using System.Diagnostics;
using System.Configuration;
using System.Collections.Specialized;

namespace TestStore
{
    public class TaskFlowService : ITaskFlowService
    {
        private AutoResetEvent instanceUnloaded = new AutoResetEvent(false);

        private SqlWorkflowInstanceStore GetInstanceStore()
        {
            var databaseSettings = ConfigurationManager.GetSection("databaseSettings") as NameValueCollection;
            var connectionString= databaseSettings["db.connectionString"];
            //SqlWorkflowInstanceStore instanceStore =
            //    new SqlWorkflowInstanceStore("Data Source=(local);Initial Catalog=TestWF4;Integrated Security=True");
            SqlWorkflowInstanceStore instanceStore =
                new SqlWorkflowInstanceStore(connectionString);
            return instanceStore;
        }

        public void Create(Request request)
        {
            SqlWorkflowInstanceStore instanceStore = GetInstanceStore();

            InstanceView view = instanceStore.Execute(instanceStore.CreateInstanceHandle(), new CreateWorkflowOwnerCommand(), TimeSpan.FromSeconds(30));

            instanceStore.DefaultInstanceOwner = view.InstanceOwner;

            IDictionary<string, object> input = new Dictionary<string, object> 
            {
                { "request" , request }
            };

            WorkflowApplication application = new WorkflowApplication(new TaskFlow(), input);

            application.InstanceStore = instanceStore;

            application.PersistableIdle = (e) =>
            {
                instanceUnloaded.Set();
                return PersistableIdleAction.Unload;
            };

            application.Unloaded = (e) =>
            {
                instanceUnloaded.Set();
            };

            application.OnUnhandledException = (ex) =>
            {
                Console.Write("Exception");
                return UnhandledExceptionAction.Terminate;
            };

            application.Run();

            instanceUnloaded.WaitOne();
        }

        public void RunInstance(Request request, string bookmark)
        {
            SqlWorkflowInstanceStore instanceStore = GetInstanceStore();

            //IDictionary<string, object> input = new Dictionary<string, object> 
            //{
            //    { "request" , request }
            //};

            WorkflowApplication application = new WorkflowApplication(new TaskFlow());

            application.InstanceStore = instanceStore;

            application.PersistableIdle = (e) =>
            {
                instanceUnloaded.Set();
                return PersistableIdleAction.Unload;
            };

            application.Completed = (workflowApplicationCompletedEventArgs) =>
            {
                Console.WriteLine("\nWorkflowApplication has Completed in the {0} state.", 
                    workflowApplicationCompletedEventArgs.CompletionState);
            };

            application.Unloaded = (workflowApplicationEventArgs) =>
            {
                Console.WriteLine("WorkflowApplication has Unloaded\n");
                instanceUnloaded.Set();
            };

            application.Load(request.WokflowId.Value);

            application.ResumeBookmark(bookmark, request);

            instanceUnloaded.WaitOne();
        }
    }
}

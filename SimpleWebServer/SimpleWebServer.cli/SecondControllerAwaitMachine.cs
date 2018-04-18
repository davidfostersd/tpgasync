#pragma warning disable 219
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SimpleWebServer.cli
{
    public class SecondControllerAwaitMachine
    {
        public Task<string> Get()
        {
            var stateMachine = new InternalMachine();
            stateMachine._controller = this;
            stateMachine._builder = AsyncTaskMethodBuilder<string>.Create();
            stateMachine._state = -1;
            stateMachine._builder.Start<SecondControllerAwaitMachine.InternalMachine>(ref stateMachine);
            return stateMachine._builder.Task;
        }

        public SecondControllerAwaitMachine()
        {
            // base.\u002Ector();
        }

        [CompilerGenerated]
        private sealed class InternalMachine : IAsyncStateMachine
        {
            public int _state;
            public AsyncTaskMethodBuilder<string> _builder;
            public SecondControllerAwaitMachine _controller;
            private HttpClient _client;
            private string _html;
            private string _htmlResult;
            private TaskAwaiter<string> _awaiter;

            public InternalMachine()
            {
                // base.\u002Ector();
            }

            void IAsyncStateMachine.MoveNext()
            {
                int num1 = this._state;
                string result;
                try
                {
                    TaskAwaiter<string> awaiter;
                    int num2;
                    if (num1 != 0)
                    {
                        this._client = new HttpClient();
                        awaiter = this._client.GetStringAsync("http://www.google.com").GetAwaiter();
                        if (!awaiter.IsCompleted)
                        {
                            this._state = num2 = 0;
                            this._awaiter = awaiter;
                            SecondControllerAwaitMachine.InternalMachine stateMachine = this;
                            this._builder
                                .AwaitUnsafeOnCompleted<TaskAwaiter<string>,
                                    SecondControllerAwaitMachine.InternalMachine>(
                                    ref awaiter, ref stateMachine);
                            return;
                        }
                    }
                    else
                    {
                        awaiter = this._awaiter;
                        this._awaiter = new TaskAwaiter<string>();
                        this._state = num2 = -1;
                    }

                    this._htmlResult = awaiter.GetResult();
                    this._html = this._htmlResult;
                    this._htmlResult = (string) null;
                    result = this._html.Substring(0, 10);
                }
                catch (Exception ex)
                {
                    this._state = -2;
                    this._builder.SetException(ex);
                    return;
                }

                this._state = -2;
                this._builder.SetResult(result);
            }

            void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
            {
            }
        }
    }
}
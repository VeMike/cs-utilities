﻿// ===================================================================================================
// = Author      :  Mike
// = Created     :  2020-06-07 20:30
// ===================================================================================================
// = Description :
// ===================================================================================================

using System;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;
using Toolbox.Utils.Dispatching;
using Toolbox.Utils.Test.MockObjects.Dispatcher;

namespace Toolbox.Utils.Test.Tests.Dispatching
{
    [TestFixture]
    public class CommonDispatcherTests
    {
        #region Tests

        [TestCaseSource(typeof(CommonDispatcherTests), nameof(GetDispatcherInstances))]
        public void DispatchThrowsOnNullCommand(IDispatcher dispatcher)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                dispatcher.Dispatch<object>(null);
            });
        }
        
        [TestCaseSource(typeof(CommonDispatcherTests), nameof(GetDispatcherInstances))]
        public void NothingHappensIfNoHandlerForCommandIsNotFound(IDispatcher dispatcher)
        {
            dispatcher.Dispatch(new object());
        }
        
        [TestCaseSource(typeof(CommonDispatcherTests), nameof(GetDispatcherInstances))]
        public void CommandIsDispatchedToSingleHandler(IDispatcher dispatcher)
        {
            var command = new CalledCommand();
            
            dispatcher.Dispatch(command);
            
            Assert.IsTrue(command.WasCalled);
        }
        
        [TestCaseSource(typeof(CommonDispatcherTests), nameof(GetDispatcherInstances))]
        public void CommandCanBeDispatchedNultipleTimes(IDispatcher dispatcher)
        {
            var command = new CalledCommand();
            
            dispatcher.Dispatch(command);
            dispatcher.Dispatch(command);
            dispatcher.Dispatch(command);
            
            Assert.IsTrue(command.WasCalled);
            
        }
        
        [TestCaseSource(typeof(CommonDispatcherTests), nameof(GetDispatcherInstances))]
        public void CommandIsDispatchedToAllHandlers(IDispatcher dispatcher)
        {
            var command = new CallTwoHandlersCommand();
            
            dispatcher.Dispatch(command);
            
            Assert.AreEqual(2, command.Calls);
        }

        #endregion

        #region Test Case Data

        public static IEnumerable<IDispatcher> GetDispatcherInstances
        {
            get
            {
                yield return new ReflectionDispatcher(Assembly.GetExecutingAssembly());
                yield return new ReflectionDependencyDispatcher<string>("Foo", Assembly.GetExecutingAssembly());
                foreach (var dispatcher in CreateRegistrationDispatchersWithHandlers())
                {
                    yield return dispatcher;
                }
            }
        }

        private static IEnumerable<IDispatcher> CreateRegistrationDispatchersWithHandlers()
        {
            var registrationDispatcher = new RegistrationDispatcher();
            registrationDispatcher.AddHandler(new CalledCommandHandler());
            registrationDispatcher.AddHandler(new FirstAllHandlersCalledHandler());
            registrationDispatcher.AddHandler(new SecondAllHandlersCalledHandler());
            yield return registrationDispatcher;
            
            var registrationDependencyDispatcher = new RegistrationDependencyDispatcher<string>("Foo");
            registrationDependencyDispatcher.AddHandler(new CalledDependencyCommandHandler());
            registrationDependencyDispatcher.AddHandler(new FirstAllDependencyHandlersCalledHandler());
            registrationDependencyDispatcher.AddHandler(new FirstAllDependencyHandlersCalledHandler());
            yield return registrationDependencyDispatcher;
        }

        #endregion
    }
}
using System;
using System.Collections.Generic;
using Xunit;

namespace BanKai.Basic
{
    // ReSharper disable ConvertToConstant.Local
    // ReSharper disable AccessToModifiedClosure
    // ReSharper disable LoopCanBeConvertedToQuery

    public class Closure
    {
        [Fact]
        public void should_capture_outer_variable()
        {
            var variableDeclaredOutsideAnonymousMethod = 1;

            Func<int> methodCapturingVariable = () => variableDeclaredOutsideAnonymousMethod;

            var returnedValue = methodCapturingVariable();

            // change variable value to correct test.
            const int expectedReturnedValue = 1;

            Assert.Equal(expectedReturnedValue, returnedValue);
        }

        [Fact]
        public void should_modify_outer_variable()
        {
            var outerVariable = 1;

            Action methodChangeVariableValue = () => outerVariable += 1;
            methodChangeVariableValue();

            // change variable value to correct test.
            const int expectedOuterVariableValue = 2;

            Assert.Equal(expectedOuterVariableValue, outerVariable); 
        }

        [Fact]
        public void should_use_caution_when_capturing_outer_variable_in_loop()
        {
            var functionList = new List<Func<int>>();

            for (var i = 0; i < 3; ++i)
            {
                functionList.Add(() => i);
            }

            var sum = 0;
            foreach (var func in functionList)
            {
                sum += func();
            }

            const int expectedSum = 9;

            Assert.Equal(expectedSum, sum);
        }
    }

    // ReSharper restore LoopCanBeConvertedToQuery
    // ReSharper restore AccessToModifiedClosure
    // ReSharper restore ConvertToConstant.Local
}
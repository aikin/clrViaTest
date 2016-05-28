using System;
using System.Collections;
using System.Collections.Generic;
using BanKai.Basic.Common;
using BanKai.Basic.Extensions;
using Xunit;

namespace BanKai.Basic
{
    // ReSharper disable UnusedVariable
    // ReSharper disable LoopCanBeConvertedToQuery

    public class EnumerationRelated
    {
        [Fact]
        public void should_always_call_move_next_before_using_dereferenced_value()
        {
            var collection = new[] {1, 2, 3};

            var enumerator = collection.GetEnumerator();
            Action getCurrentValueWithoutMoveNext = () =>
            {
                var value = enumerator.Current;
            };

            var error = getCurrentValueWithoutMoveNext.RunAndGetUnhandledException();

            // change the variable value to fix the test.
            var expectedExceptionType = typeof(InvalidOperationException);

            Assert.Equal(expectedExceptionType, error.GetType());
        }

        [Fact]
        public void should_return_true_if_not_iterating_to_the_end()
        {
            var collection = new List<string> {"good", "morning"};

            var enumerator = collection.GetEnumerator();

            var notEndOfIteration = enumerator.MoveNext();

            // change the variable value to fix the test.
            const bool expected = true;

            Assert.Equal(expected, notEndOfIteration);
        }

        [Fact]
        public void should_get_value_using_current_property()
        {
            var collection = new LinkedList<int>(new[] {1, 2, 3});

            var enumerator = collection.GetEnumerator();

            enumerator.MoveNext();

            var currentValue = enumerator.Current;

            // change the variable value to fix the test.
            const int expectedCurrentValue = 1;

            Assert.Equal(expectedCurrentValue, currentValue);
        }

        [Fact]
        public void should_iterate_through_collection()
        {
            var collection = new SortedSet<int> {10, 2, 3, 5};

            var copyOfCollection = new List<int>();

            using (var enumerator = collection.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    copyOfCollection.Add(enumerator.Current);
                }
            }

            // change the variable value to fix the test.
            var expectedCopyResult = new List<int> {2, 3, 5, 10};

            Assert.Equal(expectedCopyResult, copyOfCollection);
        }

        [Fact]
        public void should_be_simplified_using_for_each()
        {
            var collection = new SortedSet<int> { 10, 2, 3, 5 };
            var copyOfCollection = new List<int>();

            foreach (var valueInCollection in collection)
            {
                copyOfCollection.Add(valueInCollection);
            }

            // change the variable value to fix the test.
            var expectedCopyResult = new List<int> { 2, 3, 5, 10 };

            Assert.Equal(expectedCopyResult, copyOfCollection);
        }

        [Fact]
        public void should_implement_iterator_using_yield()
        {
            var demoObject = new ImplIteratorUsingYieldDemoClass();
            var numberStorage = new List<int>();

            foreach (var number in demoObject.GetOneToTen())
            {
                numberStorage.Add(number);
            }

            // change the variable value to fix the test.
            var expectedNumberStorage = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Assert.Equal(expectedNumberStorage, numberStorage);
        }

        [Fact]
        public void should_treat_yield_as_part_of_the_iteration_stream()
        {
            var demoObject = new ImplIteratorUsingYieldDemoClass();
            var numberStorage = new List<int>();

            foreach (var number in demoObject.GetOneToThreeWithMultipleYields())
            {
                numberStorage.Add(number);
            }

            // change the variable value to fix the test.
            var expectedNumberStorage = new List<int> { 1, 2, 3 };

            Assert.Equal(expectedNumberStorage, numberStorage);
        }

        [Fact]
        public void should_using_yield_break_to_stop_iterating_early()
        {
            var demoObject = new ImplIteratorUsingYieldDemoClass();
            var numberStorage = new List<int>();

            foreach (var number in demoObject.GetOnToThreeButBreakingAtTwo())
            {
                numberStorage.Add(number);
            }

            // change the variable value to fix the test.
            var expectedNumberStorage = new List<int> { 1, 2 };

            Assert.Equal(expectedNumberStorage, numberStorage);
        }

        [Fact]
        public void should_composing_iterating_sequences()
        {
            var demoObject = new ImplIteratorUsingYieldDemoClass();
            var numberStorage = new List<int>();

            foreach (var number in demoObject.GetEvenNumber(demoObject.GetOneToTen()))
            {
                numberStorage.Add(number);
            }

            // change the variable value to fix the test.
            var expectedNumberStorage = new List<int> { 2, 4, 6, 8, 10 };

            Assert.Equal(expectedNumberStorage, numberStorage);
        }
    }

    // ReSharper restore LoopCanBeConvertedToQuery
    // ReSharper restore UnusedVariable
}
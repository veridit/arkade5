using System;
using System.Xml;
using Arkivverket.Arkade.Core;

namespace Arkivverket.Arkade.Tests
{
    public abstract class BaseTest
    {
        protected readonly IArchiveContentReader ArchiveReader;

        protected TestResults TestResults;

        private TestType TestType { get; }

        protected BaseTest(TestType testType, IArchiveContentReader archiveReader)
        {
            ArchiveReader = archiveReader;
            TestType = testType;
        }

        protected abstract void Test(ArchiveExtraction archive);

        public TestResults RunTest(ArchiveExtraction archive)
        {
            TestResults = new TestResults(GetType().FullName, TestType);

            var start = DateTime.Now;
            Test(archive);
            var stop = DateTime.Now;
            var duration = stop.Subtract(start).TotalMilliseconds;

            Console.WriteLine("Duration: " + duration); // TODO: use logging mechanism instead

            TestResults.TestDuration = duration;

            return TestResults;
        }

        protected void TestSuccess(string message)
        {
            AddTestResult(ResultType.Success, message);
        }

        protected void TestError(string message)
        {
            AddTestResult(ResultType.Error, message);
        }

        private void AddTestResult(ResultType resultType, string message)
        {
            TestResults.Add(new TestResult(resultType, message));
        }

        protected void AddAnalysisResult(string key, string value)
        {
            TestResults.AddAnalysisResult(key, value);
        }
    }

    public enum TestType
    {
        Structure,
        Content
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WriteUnitTest.Services;

namespace WriteUnitTest.UnitTests.Services
{
    [TestClass]
    public class LessonServiceUnitTests
    {
        [TestMethod]
        public void UpdateLessonGrade_Test()
        {
            // Arrange
            var lessonSvc = new LessonService();

            // Act
            var grade = lessonSvc._lessonRepo.GetLesson(12).Grade;

            lessonSvc.UpdateLessonGrade(12, 98.2d);

            // Assert
            var gradeAfterUpdate = lessonSvc._lessonRepo.GetLesson(12).Grade;
            Assert.AreNotEqual(grade, gradeAfterUpdate, "failed to update grade.");

        }

        [TestMethod]
        public void TestGradePassed()
        {
            // Arrange
            var lessonSvc = new LessonService();

            // Act
            //lessonSvc.UpdateLessonGrade(12, 98.2d);
            lessonSvc.UpdateLessonGrade(12, 98.2d);

            // Assert
            Assert.IsTrue(lessonSvc._lessonRepo.GetLesson(12).IsPassed, "Test grade check failed for passed condition");
        }

        [TestMethod]
        public void TestGradeFailed()
        {
            // Arrange
            var lessonSvc = new LessonService();

            // Act
            lessonSvc.UpdateLessonGrade(12, 18.2d);

            // Assert
            Assert.IsFalse(lessonSvc._lessonRepo.GetLesson(12).IsPassed, "Test grade check failed for not");
        }
    }
}

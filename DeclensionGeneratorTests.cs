using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace TestProject2
{

    public class UnitTest1
    {
        [Fact]
        public void TestGenerate()
        {
            // Arrange
            int number = 5;
            string n = "стул";
            string g = "стула";
            string p = "стулья";
            string e = "стулья";

            string result = yulia5.DeclensionGenerator.Generate(number, n, g, p);

            Assert.Equal(e, result);
        }
    }
}
namespace Laba10
{
    public class WebResourse
    {
        public WebResourse()
        {
        }

        public WebResourse(string name)
        {
            Name = name;
        }

        public string Name { get; set; } = "Default";

        public override string ToString()
        {
            return Name;
        }
    }
}
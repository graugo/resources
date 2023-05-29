namespace HeroApp.classes
{
    public class Skill
    {
        public string name { get; set; }
        public Skill(string name) 
        {
            this.name = name;
            if (name is not null) ;
        }
    }
}

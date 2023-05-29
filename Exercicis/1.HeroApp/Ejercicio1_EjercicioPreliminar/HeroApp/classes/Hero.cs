namespace HeroApp.classes
{
    public class Hero
    {
        private string name;
        private int lvl;
        private List<Skill> skills;
        // TODO implement contract properly
        // For the time being, only bool or string implemented
        private bool inContract;

        public Hero()
        {
            this.name = "";
            this.lvl = 0;
            this.inContract = false;
            this.skills = new List<Skill>();
        }
        public string GetName() { return this.name; }
        public void SetName(string name) { this.name = name; }
        public int GetLevel() { return this.lvl; }
        public void SetLevel(int lvl) { this.lvl = lvl; }
        public List<Skill> GetSkills() { return this.skills; }
        public void AddSkills(List<Skill> skills) { this.skills.AddRange(skills); }

        public void AddSkill(Skill newSkill)
        {
            this.skills.Add(newSkill);
        }

        public override string? ToString()
        {
            return this.name;
        }
    }
}

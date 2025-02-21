namespace InterfaceSegregation
{
    public class Developer : IWorkTeamActivities, IDevelopertActivities
    {
        
        public Developer()
        {
        }

        public void Plan() 
        {
            Console.WriteLine("I'm planning user stories");
        }
        public void Comunicate() 
        {
            Console.WriteLine("I'm talking to the team user");
        }
        public void Develop() 
        {
            Console.WriteLine("I'm developing the functionalities required");
        }

    }
}
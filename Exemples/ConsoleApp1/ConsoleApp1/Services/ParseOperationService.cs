namespace ConsoleApp1.Services
{
    internal class ParseOperationService
    {
        CalculateService CalculateService;
        public ParseOperationService() 
        {
            CalculateService = new CalculateService();
        }
        public void Initialize()
        {
            bool isActive = true;
            double result = 0;
            while (isActive)
            {
                Console.WriteLine("Write the operation with each component separated by whtespace");
                Console.WriteLine(" Press enter or write exit to finish the program");
                string? operation = Console.ReadLine();
                if (String.IsNullOrEmpty(operation) || operation.ToLower().Equals("exit")) 
                    isActive = false;
                else
                {
                    result = ParseOperation(operation);
                }
                Console.WriteLine(result);
            }
            
        }

        public double ParseOperation(string operation) 
        {
            String[] SplitOp = operation.Split(' ');
            double x, y;
            if (Double.TryParse(SplitOp[0], out x) && Double.TryParse(SplitOp[2], out y)) 
            {
                return CalculateService.Calculate(x, y, SplitOp[1]);
            }
            return 0;
        }
    }
}

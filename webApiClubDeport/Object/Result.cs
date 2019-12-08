using Newtonsoft.Json;
using System;


namespace webApiClubDeport.Object
{
    public class Result
    {
        private int Code { get; set; }
        private Boolean Resultado { get; set; }
        private String Message { get; set; }
        
        public Result(int code, Boolean result, string message)
        {
            this.Resultado = result;
            this.Code = code;
            this.Message = message;
        }

        public string GetResultJson()
        {
            return JsonConvert.SerializeObject(new
            {
                resultado = this.Resultado,
                this.Code,
                this.Message
            }); 

        }
    }
}

namespace MedicalService.Authen.Common
{
    public class Result<T>
    {
        public string Message { get; set; }

        public T Value { get; set; }

        public bool Succeeded { get; set; }
    }

    public class Result : Result<object>
    {

    }
}

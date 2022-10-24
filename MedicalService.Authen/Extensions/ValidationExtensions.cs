namespace MedicalService.Authen.Extensions
{
    public static class ValidationExtensions
    {
        public static bool IsValidEmail(this string email)
        {
            if (email.EndsWith("."))
            {
                return false;
            }

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}

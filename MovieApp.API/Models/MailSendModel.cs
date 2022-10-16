namespace MovieApp.API.Models
{
    public class MailSendModel<T>
    {
        public string Email { get; set; }
        public T Data { get; set; }
    }
}

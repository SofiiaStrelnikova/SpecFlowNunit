namespace SpecFlowNunit
{
	public class User
	{
		private readonly string email;
		private readonly string password;

		public string[] DataUser { get; private set; }

		public User(string email, string password)
		{
			this.email = email;
			this.password = password;
			DataUser = new[] { this.email, this.password };
		}
	}
}

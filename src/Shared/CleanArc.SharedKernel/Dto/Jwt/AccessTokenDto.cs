namespace CleanArc.SharedKernel.Dto.Jwt
{
	public class AccessTokenDto
	{
		public string access_token { get; set; }
		public string refresh_token { get; set; }
		public string token_type { get; set; }
		public int expires_in { get; set; }
	}
}
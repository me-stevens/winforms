namespace Server
{
	public class Decoded
	{
		public string ID { get; }
		public string Command { get; }
		public string Counter { get; }

		public Decoded(string id, string command, string counter)
		{
			ID = id;
			Command = command;
			Counter = counter;
		}
	}
}

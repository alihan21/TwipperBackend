namespace TwitterBackEnd.Models.Domein
{
  public class Connection
  {
    public User Follower { get; set; }
    public string FollowerId { get; set; }
    public User Following { get; set; }
    public string FollowingId { get; set; }

    public Connection(User follower, User following)
    {
      Follower = follower;
      FollowerId = follower.Id;
      Following = following;
      FollowingId = following.Id;
    }

    protected Connection()
    {

    }
  }
}

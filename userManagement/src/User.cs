namespace NsUser
{

  class User
  {

    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public DateTime CreatedAt { get; set; }

    public User ( string firstName, string lastName, string email){

      Id = Guid.NewGuid();
      FirstName = firstName;
      LastName = lastName;
      Email = email;
      CreatedAt = DateTime.Now;

    }

  }

}
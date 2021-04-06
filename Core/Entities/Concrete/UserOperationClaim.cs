namespace Core.Entities.Concrete
{
    public class UserOperationClaim :IEntity
    {
        public int Id { get; set; }
        public int OperationClaimId { get; set; }
        public int UserId { get; set; }
    }//burda hangi user hangi rolde olaacak ona karar vereegiz.
}
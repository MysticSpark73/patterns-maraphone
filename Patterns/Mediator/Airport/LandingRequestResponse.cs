namespace Patterns.Mediator.Airport
{
    public struct LandingRequestResponse
    {
        public bool Status = false;
        public TakeoffLine? TakeoffLine = null;

        public LandingRequestResponse()
        {
        }
    }
}
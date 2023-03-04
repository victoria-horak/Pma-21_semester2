namespace DesignPattern_ChainOfResponsibility
{
    public abstract class Handler
    {
        protected Handler next;

        public void setSenior(Handler next)
        {
            this.next = next;
        }

        public abstract void Process(object request);
    }
}

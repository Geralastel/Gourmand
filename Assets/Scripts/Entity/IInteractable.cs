namespace Assets.Scripts
{
    public interface IInteractable
    {
        bool CanInteract { get; set; }
        void Interact();
    }
}

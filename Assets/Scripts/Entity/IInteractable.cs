namespace Assets.Scripts.Entity
{
    public interface IInteractable
    {
        bool CanInteract { get; set; }
        void Interact();
    }
}

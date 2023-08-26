using GameJam;

public interface IInteractable
{
    public abstract void PickUp(IPickable item);

    public abstract void Drop(IPickable item);
}

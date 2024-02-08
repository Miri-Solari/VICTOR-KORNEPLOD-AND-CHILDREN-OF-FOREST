using UnityEngine;

public class BlockActivationHandler : MonoBehaviour
{
    public void ActivateBlock()
    {
        ReplaceOnClick.ActivateTemporaryBlock();
    }

    public void ActivateBlockForReplaceOnClick()
    {
        ReplaceAndEarnPointsOnClick.ActivateTemporaryBlock();
    }
}
using UnityEngine;

public class StandaloneModule : IdentitiyClass
{
    [SerializeField] ModuleClass targetModule;

    protected virtual void OnEnable()
    {
        targetModule?.Activate();
    }

    protected virtual void OnDisable()
    {
        targetModule?.Deactivate();
    }
}

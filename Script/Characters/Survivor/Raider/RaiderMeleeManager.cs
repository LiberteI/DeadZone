using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class RaiderMeleeManager : BaseMeleeManager
{
    public int comboStep;

    public bool isInCoroutine;

    private float comboTimer;

    private Coroutine curAttack;
    void Start()
    {
        comboStep = 1;

        comboTimer = 0f;
    }
    void Update()
    {
        base.SetData();

        TryUpdateComboStep();
    }

    private void TryUpdateComboStep()
    {
        if (comboTimer > 0)
        {
            comboStep = 2;

            comboTimer -= Time.deltaTime;

            return;
        }
        if (comboStep != 1)
        {
            comboStep = 1;
        }

    }
    public void Attack()
    {
        if (comboStep == 2)
        {
            if (curAttack != null)
            {
                return;
            }
            curAttack = StartCoroutine(ExecuteMeleeAttack("Melee2"));
            comboTimer = 0f;
        }
        else
        {
            if (curAttack != null)
            {
                return;
            }
            curAttack = StartCoroutine(ExecuteMeleeAttack("Melee1"));
            comboTimer = 2f;
        }

    }

    private IEnumerator ExecuteMeleeAttack(string name)
    {
        isInCoroutine = true;

        survivor.parameter.animator.Play(name);

        yield return WaitForAnimationEnds(name);

        isInCoroutine = false;
    }

    private IEnumerator WaitForAnimationEnds(string name)
    {
        while (true)
        {
            AnimatorStateInfo info = survivor.parameter.animator.GetCurrentAnimatorStateInfo(0);
            if (info.IsName(name))
            {
                break;
            }
            yield return null;
        }

        while (true)
        {
            AnimatorStateInfo info = survivor.parameter.animator.GetCurrentAnimatorStateInfo(0);

            if (info.normalizedTime > 0.99f)
            {
                break;
            }
            yield return null;
        }
    }
}

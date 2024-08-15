using UnityEngine;
using UnityEngine.InputSystem;

namespace Exaple
{
    public class InputDataTest : InputData
    {
        public Vector2 playerInput;
        public bool desiredJump;
        public bool desiredAttack;
        public bool desiredSprint;
        public bool desiredSkillDown;
        public bool desiredSkillShoot;
        public bool desiredHurted;
        public bool desiredDied;
    }


    public class AixsInputTest : PlayerInputBase
    {
        public readonly InputDataTest inputData;

        private float currentHealth;

        public AixsInputTest(InvokerBase invoker, PlayerHealth health) : base(invoker, health)
        {
            inputData = GetInputData<InputDataTest>();

        }

        protected override void GetInputAxis()
        {
            Vector2 input = InputDevice.GetPlayerMovement();
            inputData.playerInput.x = input.x;
            inputData.playerInput.y = input.y;

            inputData.desiredJump = InputDeviceTest.GetJump();
            inputData.desiredAttack = InputDeviceTest.GetAttack();
            inputData.desiredSprint = InputDeviceTest.GetSprint();
            inputData.desiredSkillDown = InputDeviceTest.GetDown();
            inputData.desiredSkillShoot = InputDeviceTest.GetShoot();
            inputData.desiredHurted = IsHurted();
            inputData.desiredDied = IsDied();
        }

        protected override void CallCommand()
        {
            if (Mathf.Abs(inputData.playerInput.x) > 0.1f)//magnitude模长
            {
                //Debug.Log("顺利发送移动指令");
                m_invoker.Call((int)CallID.Move);//发送call的ID，它将作为枚举类型放在InvokerBase的子类中
            }

            if (inputData.desiredJump == true)
            {
                //Debug.Log("顺利发送跳跃指令");
                m_invoker.Call((int)CallID.Jump);//此处应为jump的ID
                inputData.desiredJump = false;
            }
            if (inputData.desiredAttack == true)
            {
                //Debug.Log("顺利发送攻击指令");
                m_invoker.Call((int)CallID.Attack);//此处应为attack的ID
                inputData.desiredAttack = false;
            }
            if (inputData.desiredSprint == true)
            {
                //Debug.Log("顺利发送冲刺指令");
                m_invoker.Call((int)CallID.Sprint);//此处应为sprint的ID
                inputData.desiredSprint = false;
            }
            if (inputData.desiredSkillDown == true)
            {
                //Debug.Log("顺利发送下砸指令");
                m_invoker.Call((int)CallID.SkillDown);//发送call的ID，它将作为枚举类型放在InvokerBase的子类中
                inputData.desiredSkillDown = false;
            }
            if (inputData.desiredSkillShoot == true)
            {
                //Debug.Log("顺利发送发射指令");
                m_invoker.Call((int)CallID.Shoot);//发送call的ID，它将作为枚举类型放在InvokerBase的子类中
                inputData.desiredSkillDown = false;
            }
            if (inputData.desiredHurted == true)
            {
                //Debug.Log("顺利发送死亡指令");
                m_invoker.Call((int)CallID.Hurted);//发送call的ID，它将作为枚举类型放在InvokerBase的子类中
                inputData.desiredHurted = false;
            }
            if (inputData.desiredDied == true)
            {
                //Debug.Log("顺利发送死亡指令");
                m_invoker.Call((int)CallID.Died);//发送call的ID，它将作为枚举类型放在InvokerBase的子类中
                inputData.desiredDied = false;
            }
        }

        private bool IsHurted()
        {
            if (m_health.GetHealth() < currentHealth)
            {
                currentHealth = m_health.GetHealth();
                return true;
            }
            else
            {
                currentHealth = m_health.GetHealth();
                return false;
            }
        }

        private bool IsDied()
        {
            if (currentHealth <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
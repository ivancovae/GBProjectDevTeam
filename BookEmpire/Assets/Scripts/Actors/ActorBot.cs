using UnityEngine;
using Games.Managers;

namespace Games
{
    public class ActorBot : Actor
    {
        public DataHp HP;
        public float moveSpeed;
        private Vector2 moveDir;
        private Animator animator;
        private Transform view;
        private int lookDirection = 1;

        private void Awake() 
        {
            ManagerUpdate.AddTo(this);

            animator = GetComponent<Animator>();
            view = transform.Find("view");
        }
        public override void Tick()
        {
            Debug.Log("I`m an ActorBot");

            HandleInput();
            HandleMove();
            HandleTurn();
            HandleAnimations();
        }
        private void HandleInput()
        {
            moveDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        private void HandleMove()
        {
            var nextMove = moveDir * moveSpeed;
            var speedY = moveDir.x != 0 && moveDir.y != 0 ? 0.7f : 1.0f;
            nextMove *= speedY;

            transform.Translate(nextMove * Time.deltaTime);
        }
        private void HandleTurn()
        {
            if (moveDir.x != 0)
                lookDirection = moveDir.x > 0 ? 1 : -1;
            view.localScale = new Vector3(lookDirection, 1, 1);
        }
        private void HandleAnimations()
        {
            var input = moveDir != Vector2.zero ? 1 : 0;
            animator.SetFloat("INPUT", input);
        }
    }
}
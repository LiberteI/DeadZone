using UnityEngine;

public class IdleState : PlayerIState
{
    private Player player;
    
    private Parameters parameter;

    public IdleState(Player player){
        this.player = player;

        this.parameter = player.parameter;
    }

    public void OnEnter(){
        parameter.movementManager.isRunning = false;
        parameter.animator.Play("Idle");
    }

    public void OnUpdate(){

    }

    public void HandleInput(){
        if(Input.GetKeyDown("r")){
            player.TransitionState(PlayerStateType.Reload);
            return;
        }
        if(Input.GetKeyDown("f")){
            player.TransitionState(PlayerStateType.Kick);
            return;
        }
        if(Input.GetKey("j")){
            if(Input.GetKey("s")){
                player.TransitionState(PlayerStateType.CrouchShoot);
                return;
            }
            player.TransitionState(PlayerStateType.StandShoot);
            return;
        }
        // movement
        if(Input.GetKey("a") || Input.GetKey("d")){
            if(Input.GetKey(KeyCode.LeftShift)){
                player.TransitionState(PlayerStateType.Run);
                return;
            }
            player.TransitionState(PlayerStateType.Walk);
            return;
        }

        if(Input.GetKeyDown("k")){
            if(parameter.movementManager.CanJump()){
                player.TransitionState(PlayerStateType.Jump);
                return;
            }
            
        }
        
    }

    public void OnExit(){

    }
}

public class WalkState : PlayerIState
{
    private Player player;
    
    private Parameters parameter;

    public WalkState(Player player){
        this.player = player;

        this.parameter = player.parameter;
    }

    public void OnEnter(){
        parameter.movementManager.isRunning = false;
        parameter.animator.Play("Walk");
    }

    public void OnUpdate(){
        parameter.movementManager.Walk();
    }

    public void HandleInput(){
        if(Input.GetKeyDown("r")){
            player.TransitionState(PlayerStateType.Reload);
            return;
        }
        if(Input.GetKeyDown("f")){
            player.TransitionState(PlayerStateType.Kick);
            return;
        }
        if(Input.GetKey("j")){
            if(Input.GetKey("s")){
                player.TransitionState(PlayerStateType.CrouchShoot);
                return;
            }
            player.TransitionState(PlayerStateType.StandShoot);
            return;
        }
        if(!(Input.GetKey("a") || Input.GetKey("d"))){
            player.TransitionState(PlayerStateType.Idle);
            return;
        }
        if(Input.GetKey(KeyCode.LeftShift)){
            player.TransitionState(PlayerStateType.Run);
            return;
        }
        if(Input.GetKeyDown("k")){
            if(parameter.movementManager.CanJump()){
                player.TransitionState(PlayerStateType.Jump);
                return;
            }
            
        }
    }

    public void OnExit(){

    }
}

public class RunState : PlayerIState
{
    private Player player;
    
    private Parameters parameter;

    public RunState(Player player){
        this.player = player;

        this.parameter = player.parameter;
    }

    public void OnEnter(){
        parameter.movementManager.isRunning = true;
        parameter.animator.Play("Run");
    }

    public void OnUpdate(){
        parameter.movementManager.Run();
    }

    public void HandleInput(){
        if(Input.GetKeyDown("r")){
            player.TransitionState(PlayerStateType.Reload);
            return;
        }
        if(Input.GetKeyDown("f")){
            player.TransitionState(PlayerStateType.Kick);
            return;
        }
        if(Input.GetKey("j")){
            if(Input.GetKey("s")){
                player.TransitionState(PlayerStateType.CrouchShoot);
                return;
            }
            player.TransitionState(PlayerStateType.StandShoot);
            return;

        }
        if(!Input.GetKey(KeyCode.LeftShift)){
            player.TransitionState(PlayerStateType.Walk);
            return;
        }
        if(!(Input.GetKey("a") || Input.GetKey("d"))){
            player.TransitionState(PlayerStateType.Idle);
            return;
        }
        if(Input.GetKeyDown("k")){
            if(parameter.movementManager.CanJump()){
                player.TransitionState(PlayerStateType.Jump);
                return;
            }
            
        }
    }

    public void OnExit(){

    }
}
public class JumpState : PlayerIState
{
    private Player player;
    
    private Parameters parameter;

    public JumpState(Player player){
        this.player = player;

        this.parameter = player.parameter;
    }

    public void OnEnter(){
        parameter.animator.Play("Jump");
        parameter.movementManager.Jump();
    }

    public void OnUpdate(){
        parameter.movementManager.BufferLedge();
        if(parameter.movementManager.isInMidAir){
            return;
        }
        
        player.TransitionState(PlayerStateType.Idle);
    }

    public void HandleInput(){
        
    }

    public void OnExit(){

    }
}
public class HurtState : PlayerIState
{
    private Player player;
    
    private Parameters parameter;

    public HurtState(Player player){
        this.player = player;

        this.parameter = player.parameter;
    }

    public void OnEnter(){

    }

    public void OnUpdate(){

    }

    public void HandleInput(){

    }

    public void OnExit(){

    }
}
public class DieState : PlayerIState
{
    private Player player;
    
    private Parameters parameter;

    public DieState(Player player){
        this.player = player;

        this.parameter = player.parameter;
    }

    public void OnEnter(){

    }

    public void OnUpdate(){

    }

    public void HandleInput(){

    }

    public void OnExit(){

    }
}


public class StandShootState : PlayerIState
{
    private Player player;
    
    private Parameters parameter;

    public StandShootState(Player player){
        this.player = player;

        this.parameter = player.parameter;
    }

    public void OnEnter(){
        parameter.isShooting = true;
        parameter.animator.Play("StandShoot");
        parameter.shootingManager.FireABullet(parameter.standMuzzle);
    }

    public void OnUpdate(){
        
    }

    public void HandleInput(){
        if(Input.GetKey("s")){
            player.TransitionState(PlayerStateType.CrouchShoot);
        }
        if(!Input.GetKey("j")){
            player.TransitionState(PlayerStateType.Idle);
        }
        else{
            player.TransitionState(PlayerStateType.StandShoot);
        }
    }

    public void OnExit(){
        parameter.isShooting = false;
    }
}
public class CrouchShootState : PlayerIState
{
    private Player player;
    
    private Parameters parameter;

    public CrouchShootState(Player player){
        this.player = player;

        this.parameter = player.parameter;
    }

    public void OnEnter(){
        parameter.isShooting = true;
        parameter.animator.Play("CrouchShoot");
        parameter.shootingManager.FireABullet(parameter.crouchMuzzle);
    }

    public void OnUpdate(){

    }

    public void HandleInput(){
        if(!Input.GetKey("s")){
            player.TransitionState(PlayerStateType.StandShoot);
        }
        if(!Input.GetKey("j")){
            player.TransitionState(PlayerStateType.Idle);
        }
        else{
            player.TransitionState(PlayerStateType.CrouchShoot);
        }
    }

    public void OnExit(){
        parameter.isShooting = false;
    }
}
public class KickState : PlayerIState
{
    private Player player;
    
    private Parameters parameter;

    private AnimatorStateInfo info;

    public KickState(Player player){
        this.player = player;

        this.parameter = player.parameter;
    }

    public void OnEnter(){
        parameter.isKicking = true;
        parameter.animator.Play("Kick");
        info = parameter.animator.GetCurrentAnimatorStateInfo(0);
    }

    public void OnUpdate(){
        info = parameter.animator.GetCurrentAnimatorStateInfo(0);
        if(!info.IsName("Kick")){
            return;
        }
        if(info.normalizedTime > 1f){
            player.TransitionState(PlayerStateType.Idle);
        }
    }

    public void HandleInput(){

    }

    public void OnExit(){
        parameter.isKicking = false;
    }
}
public class ReloadState : PlayerIState
{
    private Player player;
    
    private Parameters parameter;

    private AnimatorStateInfo info;

    public ReloadState(Player player){
        this.player = player;

        this.parameter = player.parameter;
    }

    public void OnEnter(){
        parameter.isReloading = true;
        parameter.animator.Play("Reload");
        info = parameter.animator.GetCurrentAnimatorStateInfo(0);
    }

    public void OnUpdate(){
        info = parameter.animator.GetCurrentAnimatorStateInfo(0);

        if(!info.IsName("Reload")){
            return;
        }
        if(info.normalizedTime > 1f){
            player.TransitionState(PlayerStateType.Idle);
        }
    }

    public void HandleInput(){

    }

    public void OnExit(){
        parameter.isReloading = false;
    }
}

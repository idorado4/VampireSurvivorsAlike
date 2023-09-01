public class ProjectileStats
{

    private ProjectileStatsSO _stats;

    public ProjectileStatsSO Stats => _stats;

    public float Damage => _stats.damage;

    public float Pierce
    {
        get => pierce;
        set => pierce = value;
    }

    public float Speed => speed;

    public float DmgRange => dmgRange;


    float damage;
   float speed;
   float pierce;
   float dmgRange;

   public ProjectileStats(ProjectileStatsSO stats)
   {
       _stats = stats;
   }
 
}
using System.Collections.Generic;

//get all timings and add is hit to them
public class HitTracker
{
    public struct HitData
    {
        public MoveCombo.Timing timing;
        public bool hit;
    }

    List<HitData> hitDatas;


    public HitTracker(List<MoveCombo> moves)
    {
        hitDatas = new List<HitData>();
        foreach (MoveCombo move in moves)
        {
            foreach (MoveCombo.Timing timing in move.moves)
            {
                HitData data = new HitData();
                data.timing = timing;
                data.hit = false;
                hitDatas.Add(data);
            }
        }
    }

 

    public List<HitData> GetHitData()
    {
        return hitDatas;
    }


}

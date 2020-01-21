using System;
using System.Text;

namespace hashes
{
    public class GhostsTask :
        IFactory<Document>, IFactory<Vector>, IFactory<Segment>, IFactory<Cat>, IFactory<Robot>,
        IMagic
    {
        byte[] text = { 1, 1, 2, 3, 5, 8 };
        Vector newVector = new Vector(1, 1);
        Cat kitty = new Cat("Count", "Bombay cat", DateTime.Today);

        public void DoMagic()
        {
            kitty.Rename("Countless");
            newVector.Add(new Vector(5, 5));
            Robot.BatteryCapacity += 5;
            text[5] = 13;
        }

        Document IFactory<Document>.Create()
        {
            Document document = new Document("1984", Encoding.UTF8, text);
            return document;
        }

        Vector IFactory<Vector>.Create()
        {
            Vector vector = newVector;
            return vector;
        }

        Segment IFactory<Segment>.Create()
        {
            Segment segment = new Segment(new Vector(0, 0), newVector);
            return segment;
        }

        Cat IFactory<Cat>.Create()
        {
            return kitty;
        }

        Robot IFactory<Robot>.Create()
        {
            Robot robot = new Robot("HK-47");
            return robot;
        }
    }
}
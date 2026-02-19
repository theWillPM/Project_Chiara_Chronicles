using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiaraChronicles
{
    // Define an interface for entities that can collide
    internal interface ICollision
    {
        Rectangle BoundingBox { get; }

        bool IsColliding(Entity e);
    }
}

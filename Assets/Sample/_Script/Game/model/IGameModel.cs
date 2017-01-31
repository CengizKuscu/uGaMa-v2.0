using System.Collections.Generic;
using uGaMa.Model;

namespace Sample
{
    public interface IMyGameModel : IModel
    {
        List<int> TouchOrder { get; set; }

        int Life { get; set; }

    }
}
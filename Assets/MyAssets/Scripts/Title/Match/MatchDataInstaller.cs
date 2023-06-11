using Zenject;

namespace MyAssets.Scripts.Title
{
    public class MatchDataInstaller : MonoInstaller {
        public override void InstallBindings () {
            Container.Bind<IMatchData>().To<MatchData> ().AsCached ();
        }
    }
}

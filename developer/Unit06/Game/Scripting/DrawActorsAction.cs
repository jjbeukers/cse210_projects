using System.Collections.Generic;
using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    /// <summary>
    /// <para>An output action that draws all the actors.</para>
    /// <para>The responsibility of DrawActorsAction is to draw each of the actors.</para>
    /// </summary>
    public class DrawActorsAction : Action
    {
        private VideoService _videoService;

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public DrawActorsAction(VideoService videoService)
        {
            this._videoService = videoService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            _videoService.ClearBuffer();

            foreach (Cycle cycle in cast.GetActors("cycles"))
            {
                List<Actor> segments = cycle.GetSegments();
                _videoService.DrawActors(segments);
            }
            
            Actor score = cast.GetFirstActor("score");
            List<Actor> messages = cast.GetActors("messages");
            
            //_videoService.DrawActor(score);
            _videoService.DrawActors(messages);
            _videoService.FlushBuffer();
        }
    }
}
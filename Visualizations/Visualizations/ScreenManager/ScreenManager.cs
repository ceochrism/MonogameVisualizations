using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visualizations
{
    class ScreenManager
    {
        Dictionary<ScreenNames, Screen> screenMap = new Dictionary<ScreenNames, Screen>();

        Stack<Screen> screenStack = new Stack<Screen>();

        Screen activeScreen => screenStack.Peek();

        public ScreenManager()
        {

        }
        
        public void LoadContent(ContentManager Content)
        {
            foreach(var screenPair in screenMap)
            {
                screenPair.Value.LoadContent(Content);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var screen in screenStack.Reverse())
            {
                screen.Draw(spriteBatch);
            }
        }

        public void Update(GameTime gameTime)
        {
            if(screenStack.Count <= 0)
            {
                throw new Exception("No Screen in Stack");
            }
            activeScreen.Update(gameTime);
        }

        public bool RegisterScreen(ScreenNames name, Screen screen)
        {
            if(screenMap.ContainsKey(name))
            {
                return false;
            }

            screenMap.Add(name, screen);
            return true;
        }

        public void LeaveScreen()
        {
            screenStack.Pop();
        }

        public void EnterScreen(ScreenNames name)
        {
            screenStack.Push(screenMap[name]);
        }

    }
}

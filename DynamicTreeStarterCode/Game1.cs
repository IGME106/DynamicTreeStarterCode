using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DynamicTreeStarterCode
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

        // Random number generator
        Random myRandom = new Random();

		// The three trees
		Tree treeRed;
		Tree treeGreen;
		Tree treeBlue;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			// TODO: Add your initialization logic here

			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			// Create the three trees
			treeRed = new Tree(spriteBatch, Color.Red);
			treeGreen = new Tree(spriteBatch, Color.Green);
			treeBlue = new Tree(spriteBatch, Color.DodgerBlue);

            // Populate treeRed
            for (int i = 0; i < 200; i++)
            {
                treeRed.Insert(myRandom.Next(-100, 100));
            }

            // Populate treeGreen
            for (int i = 0; i < 35; i++)
            {
                treeGreen.Insert(i);
            }

            // Populate treeBlue
            for (int i = 0; i < 2000; i += 200)
            {
                treeBlue.Insert(i);
                
                if ((i == 200) || ((i % 400) == 0))
                {
                    for (int j = 1; j < 10; j++)
                    {
                        treeBlue.Insert((i - 100) + j);

                        if ((j == 5) || ((j % 5) == 0))
                        {
                            for (int k = 1; k < 10; k++)
                            {
                                treeBlue.Insert((j - 10) + k);
                            }
                        }
                    }
                }
            }
        }

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// game-specific content.
		/// </summary>
		protected override void UnloadContent()
		{
			// TODO: Unload any non ContentManager content here
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			// After you have the rest of the assignment working:
			//  What happens if you insert a new piece of 
			//  data into the trees each frame?

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Black);

			// Draw the trees
			treeRed.Draw(new Vector2(200, 400));
			treeGreen.Draw(new Vector2(400, 400));
			treeBlue.Draw(new Vector2(600, 400));

			base.Draw(gameTime);
		}
	}
}

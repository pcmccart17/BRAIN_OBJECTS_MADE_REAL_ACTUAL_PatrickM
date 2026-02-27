using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BRAIN_OBJECTS_MADE_REAL_ACTUAL_PatrickM
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D playerTexture;
        private Vector2 playerPosition;

        private float playerSpeed = 150f;

        private DoubleDouble coffee;
        private KeyboardState previousKeyboard;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            playerPosition = new Vector2(300, 200);

            //coffee has 2 uses, double the speed and lasts for 4 seconds
            coffee = new DoubleDouble(2, 2f, 4f);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            playerTexture = new Texture2D(GraphicsDevice, 50, 50);
            Color[] data = new Color[50 * 50];

            for (int i = 0; i < data.Length; i++)
                data[i] = Color.Red;

            playerTexture.SetData(data);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState keyboard = Keyboard.GetState();
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            //Activates the coffe boost when Spacebar is pressed
            if (keyboard.IsKeyDown(Keys.Space) && previousKeyboard.IsKeyUp(Keys.Space))
            {
                coffee.useCoffee();
            }

            coffee.decreaseBoostTime(gameTime);

            float currentSpeed = playerSpeed;

            if (coffee.GetIsActive())
            {
                currentSpeed *= coffee.GetSpeedBoost();
            }

            //Movement of WASD 

            if (keyboard.IsKeyDown(Keys.W))
                playerPosition.Y -= currentSpeed * deltaTime;

            if (keyboard.IsKeyDown(Keys.S))
                playerPosition.Y += currentSpeed * deltaTime;

            if (keyboard.IsKeyDown(Keys.A))
                playerPosition.X -= currentSpeed * deltaTime;

            if (keyboard.IsKeyDown(Keys.D))
                playerPosition.X += currentSpeed * deltaTime;

            previousKeyboard = keyboard;



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.BlueViolet);

            _spriteBatch.Begin();
            _spriteBatch.Draw(playerTexture, playerPosition, Color.White);
            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}

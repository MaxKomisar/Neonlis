using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Neonlis2game
{
    class ParticleController
    {
        public List<Particle> particles;
        private Random random;
        public ParticleController()
       {
            this.particles = new List<Particle>();
            random = new Random();
        }

        public void EngineRocket(Vector2 position,Texture2D texture) // функция, которая будет генерировать частицы
        {
            for (int a = 0; a < 15; a++) // создаем 2 частицы дыма для трейла
            {
                Vector2 velocity = AngleToV2((float)(Math.PI * 2d * random.NextDouble()), 1.9f+(float)random.Next(1,3));
                float angle = 0;
                float angleVel = 0;
                Vector4 color = new Vector4(1f, 1f, 1f, 1f);
                float size = 1f;
                int ttl = 10 + random.Next(30,100); // Вркмя и дальность полёта частицы
                float sizeVel = 0;
                float alphaVel = 0;


                GenerateNewParticle(texture, position, velocity, angle, angleVel, color, size, ttl, sizeVel, alphaVel);
            }
          

            for (int a = 0; a < 17; a++) // создаем 10 дыма, но на практике — реактивная струя для трейла
            {
                Vector2 velocity = Vector2.Zero;
                float angle = 0;
                float angleVel = 0;
                Vector4 color = new Vector4(1.0f, 0.5f, 0.5f, 1f);
                float size = 0.1f + 1.8f * (float)random.NextDouble();
                int ttl = 40;
                float sizeVel = -0.5f;
                float alphaVel = 0.1f;


                GenerateNewParticle(texture, position, velocity, angle, angleVel, color, size, ttl, sizeVel, alphaVel);
            }

        }
        


     

        private Particle GenerateNewParticle(Texture2D texture, Vector2 position, Vector2 velocity,
            float angle, float angularVelocity, Vector4 color, float size, int ttl, float sizeVel, float alphaVel)
        {
            Particle particle = new Particle(texture, position, velocity, angle, angularVelocity, size, ttl, sizeVel, alphaVel);
            particles.Add(particle);
            return particle;
        }


        public void Update(GameTime gameTime)
        {

            for (int particle = 0; particle < particles.Count; particle++)
            {

                particles[particle].Update();
                if (particles[particle].Size <= 0 || particles[particle].TTL <= 0) // если время жизни частички или её размеры равны нулю, удаляем её
                {


                    particles.RemoveAt(particle);
                    particle--;

                }
              
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // ставим режим смешивания Addictive

            for (int index = 0; index < particles.Count; index++) // рисуем все частицы
            {
                particles[index].Draw(spriteBatch);
            }


        }


        public Vector2 AngleToV2(float angle, float length)
        {
            Vector2 direction = Vector2.Zero;
            direction.X = (float)Math.Cos(angle) * length;
            direction.Y = -(float)Math.Sin(angle) * length;
            return direction;
        }
       
    }
}
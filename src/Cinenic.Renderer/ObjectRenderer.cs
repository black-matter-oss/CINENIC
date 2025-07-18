using System.Numerics;
using Cinenic.Renderer.Shader;
using Cinenic.Renderer.Shader.Pipelines;
using Cinenic.Renderer.Vulkan;

namespace Cinenic.Renderer {
	
	public abstract class ObjectRenderer : IRenderer {

		public string Id { get; }
		public int Priority { get; init; } = 1000;
		
		public DefaultSceneShaderPipeline ShaderPipeline { get; }
		
		public ObjectRenderer(string id, DefaultSceneShaderPipeline shaderPipeline) {
			Id = id;
			ShaderPipeline = shaderPipeline;
		}

		public abstract void AddObject(RenderableModel model, Matrix4x4 matrix);
		
		public abstract void Render(RenderQueue queue, TimeSpan delta);
		public abstract void Reset();
		
		public static ObjectRenderer Create(IPlatform platform, DefaultSceneShaderPipeline shaderPipeline) {
			return platform switch {
				VkPlatform vkPlatform => new VkObjectRenderer("main", shaderPipeline),
				_ => throw new NotImplementedException("PlatformImpl")
			};
		}
	}
}

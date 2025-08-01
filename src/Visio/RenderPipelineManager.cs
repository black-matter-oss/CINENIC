using System.Diagnostics;
using Visio.Renderer;
using Visio.Renderer.OpenGL;
using Visio.Renderer.Shader;
using Visio.Renderer.Vulkan;
using Silk.NET.Vulkan;
using Framebuffer = Visio.Renderer.Framebuffer;

namespace Visio {
	
	public static class RenderPipelineManager {
		
		public static Dictionary<string, RenderPipeline> Pipelines { get; } = [];
		public static Dictionary<RenderPipeline, bool> PipelineStates { get; } = [];

		public static RenderPipeline Create(
			IPlatform platform,
			string id,
			RenderQueue queue,
			IShaderPipeline shaderPipeline,
			bool disabled = false
		) {
			RenderPipeline pipeline;

			switch(platform) {
				case VkPlatform vkPlatform:
					Debug.Assert(queue is VkRenderQueue);
					pipeline = new VkRenderPipeline(vkPlatform, (VkRenderQueue) queue, shaderPipeline);
					break;
				default:
					throw new NotImplementedException("PlatformImpl");
			}

			Pipelines[id] = pipeline;
			PipelineStates[pipeline] = !disabled;
			return pipeline;
		}
		
		public static void Add(string id, RenderPipeline pipeline, bool disabled = false) {
			Pipelines[id] = pipeline;
			PipelineStates[pipeline] = !disabled;
		}

		public static RenderPipeline? Get(string id) {
			if(!Pipelines.TryGetValue(id, out var pipeline)) {
				return pipeline;
			}

			return null;
		}

		public static bool IsEnabled(RenderPipeline pipeline) => PipelineStates[pipeline];
		public static void SetEnabled(RenderPipeline pipeline, bool enabled) => PipelineStates[pipeline] = enabled;
		public static void ToggleEnabled(RenderPipeline pipeline) => PipelineStates[pipeline] = !PipelineStates[pipeline];
	}
}

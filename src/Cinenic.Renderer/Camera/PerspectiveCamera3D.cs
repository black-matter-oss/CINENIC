using System.Numerics;
using Cinenic.Extensions.CSharp;

namespace Cinenic.Renderer.Camera {
	
	public class PerspectiveCamera3D : Camera3D {

		public PerspectiveCamera3D(Framebuffer framebuffer) : base(framebuffer) { }
		public PerspectiveCamera3D(int width, int height) : base(width, height) { }

		protected override void RecalculateProjectionMatrix() {
			ProjectionMatrix = Matrix4x4.CreatePerspectiveFieldOfView(
				FieldOfView.ToRadians(),
				Width / Height,
				ZNear,
				ZFar
			);
			
			Matrix4x4.Invert(ProjectionMatrix, out var ipm);
			InverseProjectionMatrix = ipm;
		}
	}
}

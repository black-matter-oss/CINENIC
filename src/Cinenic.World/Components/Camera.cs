using Cinenic.Renderer.Camera;

namespace Cinenic.World.Components {

	public record struct Camera2D(Renderer.Camera.Camera2D Camera, bool Enabled = true);
	public record struct Camera3D(Renderer.Camera.Camera3D Camera, bool Enabled = true);
}

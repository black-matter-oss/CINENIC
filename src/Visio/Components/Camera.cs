namespace Visio.Components {

	[Component]
	public record struct Camera2D(Renderer.Camera.Camera2D Camera, bool Enabled = true);

	[Component]
	public record struct Camera3D(Renderer.Camera.Camera3D Camera, bool Enabled = true) {

		public override string ToString() {
			return $"[Enabled={Enabled}, Camera={Camera}]";
		}
	}
}

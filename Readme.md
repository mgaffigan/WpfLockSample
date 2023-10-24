# Example showing WPF not updating the UI when it changes during a lock screen
Using WPF on .Net 7, updates to window content when the windows session is locked do not result in redraw/paint of the window.  This behavior is not reproducible on .Net Framework.

## Repro
1. Run the app
1. Lock your computer (which sets the `textblock.Text` to "Locked")
1. Unlock your computer
1. Observe that the UI does not say "Locked".  Hover over where the button would be and observe that the mouse cursor does change.
1. Wait for the 15s timer to update the UI again
1. The window is repainted

## Expected behavior
The window shows the "Locked" text when the computer is unlocked.

## Workarounds
1. Use .Net Framework<br/>Compiling the app with `<TargetFramework>net46</TargetFramework>` fixes the bug.
1. Use software rendering<br/>Setting `RenderOptions.ProcessRenderMode = RenderMode.SoftwareOnly;` fixes the bug.
1. Minimizing the window will trigger redraw

## Environment
* Windows 11 22H2 (22621.2428)
* .NET 7.0.401
* Lenovo ThinkPad X1 Yoga 8th Gen
* Intel(R) Iris(R) Xe Graphics v31.0.101.4502 ([DxDiag](DxDiag.txt))
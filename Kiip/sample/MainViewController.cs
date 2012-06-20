// 
//  Copyright 2012  James Clancey, Xamarin Inc  (http://www.xamarin.com)
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Kiip;

namespace sample
{
	public partial class MainViewController : UIViewController
	{
		public MainViewController () : base ("MainViewController", null)
		{
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			toggleStatusBar.ValueChanged += toggleSwitchValueChanged;
		}

		void toggleSwitchValueChanged (object sender, EventArgs e)
		{
			Console.WriteLine("ChangeD");
		}
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;
			
			ReleaseDesignerOutlets ();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}

		partial void saveLeaderboard ()
		{
			KPManager.SharedManager.UpdateScore(100, leaderboard_id.Text);
		}
		partial void setLocation ()
		{
			KPManager.SharedManager.UpdateLocation((double)37.7753, (double)-122.4189);
		}
		partial void showFullscreen ()
		{
			Console.WriteLine("Show Notification");
			AppDelegate appDelegate = (AppDelegate)UIApplication.SharedApplication.Delegate;
			NSMutableArray queue = appDelegate.Resources;
			UInt16 count = Convert.ToUInt16(queue.Count - 1);
			while(queue.Count > 0)
			{

				NSMutableDictionary reward = new NSMutableDictionary(new NSDictionary(queue.ValueAt(count)));
				reward.SetValueForKey(NSNumber.FromInt32((int)KPViewPosition.FullScreen),new NSString("position"));
				KPManager.SharedManager.PresentReward(reward);
				queue.RemoveObject((int)queue.Count - 1);
			}

//			NSLog(@"show fullscreen");
//    MainAppDelegate *appDelegate = (MainAppDelegate *)[[UIApplication sharedApplication] delegate];
//
//    NSMutableArray *queue = [appDelegate resources];
//    while ([queue count] > 0) {
//        NSMutableDictionary* reward = [NSMutableDictionary dictionaryWithDictionary:[queue objectAtIndex:[queue count] - 1]];
//        [reward setObject:[NSNumber numberWithInt:kKPViewPosition_FullScreen] forKey:@"position"];
//
//        [[KPManager sharedManager] presentReward:reward];
//        [queue removeObjectAtIndex:[queue count] - 1];
   // }
		}
		partial void showNotification ()
		{
			Console.WriteLine("Show Notification");
			AppDelegate appDelegate = (AppDelegate)UIApplication.SharedApplication.Delegate;
			NSMutableArray queue = appDelegate.Resources;
			UInt16 count = Convert.ToUInt16(queue.Count - 1);
			while(queue.Count > 0)
			{

				NSMutableDictionary reward = new NSMutableDictionary(new NSDictionary(queue.ValueAt(count)));
				reward.SetValueForKey(NSNumber.FromInt32((int)KPViewPosition.FullScreen),new NSString("position"));
				KPManager.SharedManager.PresentReward(reward);
				queue.RemoveObject((int)queue.Count - 1);
			}

//			 NSLog(@"show notification");
//    MainAppDelegate *appDelegate = (MainAppDelegate *)[[UIApplication sharedApplication] delegate];
//
//    kpViewPosition = (kpViewPosition == kKPViewPosition_Top) ? kKPViewPosition_Bottom : kKPViewPosition_Top;
//    NSMutableArray *queue = [appDelegate resources];
//    NSLog(@"queue length: %d", [queue count]);
//    while ([queue count] > 0) {
//        NSMutableDictionary* reward = [NSMutableDictionary dictionaryWithDictionary:[queue objectAtIndex:[queue count] - 1]];
//        [reward setObject:[NSNumber numberWithInt:kpViewPosition] forKey:@"position"];
//
//        [[KPManager sharedManager] presentReward:reward];
//        [queue removeObjectAtIndex:[queue count] - 1];
//    }


		}

		partial void unlockAchievement ()
		{
			KPManager.SharedManager.UnlockAchievement(achievement_id.Text);
		}
		partial void getActivePromos ()
		{
			KPManager.SharedManager.GetActivePromos();
		}

	}
}


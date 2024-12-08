export interface Automation {
    automationId: number;
    deviceId: number;
    triggerEvent: string; // e.g., "TimeSchedule"
    action: string; // e.g., "TurnOn", "TurnOff"
    timeSchedule: string; // The time the action should be triggered, e.g., "22:00"
    status: string; // Active or Inactive
  }
  
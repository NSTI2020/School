import { InstantMessage } from './InstantMessage';
import { SocialNetwork } from './SocialNetwork';

export class Contact {
    Id: number;
    cellphone: string;
    homephone: string;
    comercialphone: string;
    email: string;
    instantMessageId: number;
    instantMessage: InstantMessage;
    socialNetworkId: number;
    socialNetwork: SocialNetwork;
}

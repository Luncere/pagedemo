#include <iostream>
#include <iomanip>
using namespace std;
int n, a, b;													//n=���� a=�h�� b=��F����
int main() {
	cin >> n;													//�`����
	if (n > 10) {
		while (n > 0) {											//�𸭦��X�h
			n = n - 3 - a;
			a++;
			b = n + a + 3 - 1;									//�p��Ѿl��������@��F
		}
		if (b == 0)												//�H��F�N�������ۦa���@�h��
			b = a + 3 - 1;
		for (int i = 0; i < a - 1; i++) 						//���X�h  �N��F�h���ҥH��@
			for (int j = 0; j < 3 + i; j++) {					//�@�h���X�� �C�h�h�[i
				for (int l = 0; l < 2 * (a - 1) - i - j; l++)		//�C�h���j���|�h2 �Hi��h��h�w�� �Hj��h�C�h�ƭ� 
					cout << setw(1) << "";
				for (int k = 0; k < 2 * (i + j) + 1; k++)		//�@���X�� i���ܰ_�l�@���𸭦��X�� j���ܨC���e��
					cout << "*";								//��X�Ÿ�*
				cout << endl;									//�C���槹�@������
			}

		for (int i = 0; i < b; i++) {							//��F�h��
			for (int m = 0; m < 2 * (a - 1); m++)					//�p���ڶZ���𤤤ߦh��
				cout << setw(1) << "";
			cout << "*";
			cout << endl;
		}
		system("Pause");										//�H�K�[��t�Ͼ�
	}
}
/*
²��:���H���רӧP�_���X�h��,�A���Ӧh�l����@��F,���p��n���O��,�ۦ��h�@�h,�N���ܦ���F
��J��X�W�h:��J:�𪺰��� ��X:�t�Ͼ�ϫ�
�p�⤽��,��z����:���״��⦨�𪺼h��:�H����覡 �C�B��@���p��@�h(a)�ñN(b)�O����F����				Line08-Line12
				  ��̫�Ѿl��������n���P��(�S����F��)�N�̫�@�h����Ʀ���F						Line13-Line14
				  �Ĥ@�h�j��:��ܼh�ƭn��X�X����(a-1(��F))�M�w										Line15
				  �ĤG�h�j��:��ܨC�h�n��X�X����(���),�_�l3��,�C�h�@�h�h�[1��(�ܼ�i)				Line16
				  �ĤT�h-1�j��:��X�䶡�j��																Line17
								 2*a=�̰��h���T�w���j
								 j=�C��������(�ϸ����X��)
								 i=�C�h���_�l��h�����j��
				  �ĤT�h-2�j��:��X�Ÿ�*																Line19
								 2*(i+j)=�C�@���һݭn���Ÿ�*
									j=�C��+1
									i=�C�h+1
								 1=������F
				 �Ĥ@�h�j��:��X��F����(b)																Line24
				 �ĤG�h�j��:�p��Z����F�ݦh�ֶ��j														Line25
							2*(a-1)=�C�@�h�����j��2,�]���N�̰��h�ƥh����F�A��2����Z����F�һݶ��j		
�ܼƷN�q�|������:n=����
				 a=�h��
				 b=��F����
				 i=��e�h��
				 j=��h����
*/
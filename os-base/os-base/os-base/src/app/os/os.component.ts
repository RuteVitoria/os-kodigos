import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { OrdemServicoService } from '../services/ordem-servico.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-ordem-servico',
  templateUrl: './os.component.html',
  styleUrls: ['./os.component.css']
})
export class OrdemServicoComponent {
  osForm: FormGroup;
  imagePreview: string | ArrayBuffer | null = null;
  uploading = false;
  uploadProgress = 0;

  constructor(
    private fb: FormBuilder,
    private osService: OrdemServicoService,
    private snackBar: MatSnackBar
  ) {
    this.osForm = this.fb.group({
      descricao: [''],
      item1: [false],
      item2: [false],
      item3: [false],
      item4: [false]
    });
  }

  onFileSelected(event: Event): void {
    const file = (event.target as HTMLInputElement).files?.[0];
    if (!file) return;

    const reader = new FileReader();
    reader.onload = () => (this.imagePreview = reader.result);
    reader.readAsDataURL(file);
  }

  removeImage(): void {
    this.imagePreview = null;
    this.uploadProgress = 0;
  }

  onSubmit(): void {
    const formValue = this.osForm.value;

    const payload = {
      descricao: formValue.descricao || '',
      equipamentoLimpo: !!formValue.item1,
      pecasSubstituidas: !!formValue.item2,
      testeFuncionamento: !!formValue.item3,
      areaOrganizada: !!formValue.item4,
      imagemBase64: this.imagePreview || null,
    };

    this.osService.enviarOrdemServico(payload).subscribe({
      next: () => {
        this.snackBar.open('Ordem de Serviço enviada com sucesso!', 'Fechar', { duration: 3000 });
        this.osForm.reset();
        this.imagePreview = null;
      },
      error: (err) => {
        console.error(err);
        this.snackBar.open('Erro ao enviar OS.', 'Fechar', { duration: 3000 });
      }
    });
  }
}
